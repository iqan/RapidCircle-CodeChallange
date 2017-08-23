var graphController = function ($scope, authService, friendsService, edgesService) {
    
    $scope.newPost = {
        UserId:"",
        Text: ""
    };
    $scope.accessToken = "";
    $scope.nodes = [];
    $scope.edges = [];
    $scope.errorMessage;

    authService.getAccessToken();
    $scope.accessToken = sessionStorage.getItem('iqans.accessToken');

    $scope.getFriends = function () {
        console.log('getting friends.');
        return friendsService.getFriends($scope.accessToken)
            .then(function (result) {
                console.log('got friends');
                $scope.nodes = result.data;
                console.log(result.data);
            });
    };

    $scope.getEdges = function () {
        console.log('getting edges.');
        return edgesService.getEdges($scope.accessToken)
            .then(function (result) {
                console.log('got edges');
                $scope.edges = result.data;
                console.log(result.data);
            });
    };

    $scope.loadGraph = function () {
        $scope.getEdges()
        .then(function () {
            $scope.getFriends()
            .then(function () {
                init($scope.nodes, $scope.edges);
                console.log('graph generated');
            });            
        });        
    };

    checkToken = function () {
        if ($scope.accessToken === null || $scope.accessToken === undefined) {
            tokenFromStorage = sessionStorage.getItem('iqans.accessToken');
            if ($scope.accessToken === null || $scope.accessToken === undefined) {
                authService.getAccessToken()
                    .then(function (result) {
                        $scope.accessToken = result.data;
                        sessionStorage.setItem('iqans.accessToken', result.data);
                    });
            }else{
                $scope.accessToken = tokenFromStorage;
            }
        }
    };

    var highlightColor = "red";  // color parameterization

    function init(nodeDataArray, linkDataArray) {
        if (window.goSamples) goSamples();  // init for these samples -- you don't need to call this
        var $ = go.GraphObject.make;  // for conciseness in defining templates

        myDiagram =
          $(go.Diagram, "myDiagramDiv", // must be the ID or reference to div
            {
                initialAutoScale: go.Diagram.Uniform,
                padding: 10,
                contentAlignment: go.Spot.Center,
                layout:
                  $(WheelLayout,  // set up a custom CircularLayout
                    // set some properties appropriate for this sample
                    {
                        arrangement: go.CircularLayout.ConstantDistance,
                        nodeDiameterFormula: go.CircularLayout.Circular,
                        spacing: 10,
                        aspectRatio: 0.7,
                        sorting: go.CircularLayout.Optimized
                    }),
                isReadOnly: true,
                click: function (e) {  // background click clears any remaining highlighteds
                    e.diagram.startTransaction("clear");
                    e.diagram.clearHighlighteds();
                    e.diagram.commitTransaction("clear");
                }
            });

        // define the Node template
        myDiagram.nodeTemplate =
          $(go.Node, "Horizontal",
            {
                selectionAdorned: false,
                locationSpot: go.Spot.Center,  // Node.location is the center of the Shape
                locationObjectName: "SHAPE",
                mouseEnter: function (e, node) {
                    node.diagram.clearHighlighteds();
                    node.linksConnected.each(function (l) { highlightLink(l, true); });
                    node.isHighlighted = true;
                    var tb = node.findObject("TEXTBLOCK");
                    if (tb !== null) tb.stroke = highlightColor;
                },
                mouseLeave: function (e, node) {
                    node.diagram.clearHighlighteds();
                    var tb = node.findObject("TEXTBLOCK");
                    if (tb !== null) tb.stroke = "black";
                }
            },
            new go.Binding("text", "text"),  // for sorting the nodes
            $(go.Shape, "Ellipse",
              {
                  name: "SHAPE",
                  fill: "lightgray",  // default value, but also data-bound
                  stroke: "transparent",  // modified by highlighting
                  strokeWidth: 2,
                  desiredSize: new go.Size(20, 20),
                  portId: ""
              },  // so links will go to the shape, not the whole node
              new go.Binding("fill", "color"),
              new go.Binding("stroke", "isHighlighted",
                             function (h) { return h ? highlightColor : "transparent"; })
                            .ofObject()),
            $(go.TextBlock,
              { name: "TEXTBLOCK" },  // for search
              new go.Binding("text", "text"))
          );

        function highlightLink(link, show) {
            link.isHighlighted = show;
            link.fromNode.isHighlighted = show;
            link.toNode.isHighlighted = show;
        }

        // define the Link template
        myDiagram.linkTemplate =
          $(go.Link,
            {
                routing: go.Link.Normal,
                curve: go.Link.Bezier,
                selectionAdorned: false,
                mouseEnter: function (e, link) { highlightLink(link, true); },
                mouseLeave: function (e, link) { highlightLink(link, false); }
            },
            $(go.Shape,
              new go.Binding("stroke", "isHighlighted",
                             function (h, shape) { return h ? highlightColor : shape.part.data.color; })
                            .ofObject(),
              new go.Binding("strokeWidth", "isHighlighted",
                             function (h) { return h ? 2 : 1; })
                            .ofObject())
          );

        nodeDataArray.forEach(function (item, index, arr) {
            nodeDataArray[index].color = go.Brush.randomColor(128, 240);
        });
        linkDataArray.forEach(function (item, index, arr) {
            linkDataArray[index].color = go.Brush.randomColor(0, 127);
        });

        myDiagram.model = new go.GraphLinksModel(nodeDataArray, linkDataArray);
    };

    initPage = function () {
        authService.getAccessToken().then(function (result) {
            sessionStorage.removeItem('iqans.accessToken');
            $scope.accessToken = result.data;
            sessionStorage.setItem('iqans.accessToken', result.data);
        });
    };

    initPage();
    $scope.loadGraph();
}

graphController.$inject = ['$scope', 'authService', 'friendsService', 'edgesService'];