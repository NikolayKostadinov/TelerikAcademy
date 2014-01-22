
var controls = (function () {

    function CreateElement() {
        var element = document.createElement(arguments[0]);
        if (arguments[1][1]) {
            var args = arguments[1][1];
            for (var argument in args) {
                element[argument] = args[argument];
            }
        }

        return element;
    }

    function Node(nodeType) {
        this.nodeType = nodeType;
        this.element = CreateElement(this.nodeType, arguments);

        this.addNode = function (nodeType) {
            var innerType;
            if (nodeType) {
                innerType = nodeType
            } else {
                if (this.nodeType == 'div') {
                    innerType = 'ul';
                } else if (this.nodeType == 'ul') {
                    innerType = 'li';
                } else if (this.nodeType == 'li') {
                    innerType = 'ul';
                }
            }

            if (arguments.length < 1) {
                var node = new Node(innerType)
            } else {
                var args = arguments[1];
                var node = new Node(innerType, args);
            }

            this.element.appendChild(node.element);
            return node;
        }

        this.content = function (content) {
            if (this.nodeType == 'ul') {
                var parentNode = this.addNode('li');
                var args = arguments;
                var childNode = parentNode.addNode('a', { href: "#", innerHTML: content });
                parentNode.element.appendChild(childNode.element);
                this.element.appendChild(parentNode.element);
            } else {
                var args = arguments;
                var node = this.addNode('a', { href: "#", innerHTML: content });
                this.element.appendChild(node.element);
            }
        }

        return this;
    }

    function treeView(value) {
        var treeViewBaseElement;
        var pattern = /(^[\w]+)([.#])/g;
        var regex = new RegExp(pattern);
        var splitValue = value.split(regex);

        if (splitValue[2] == "#") {
            treeViewBaseElement = new Node(splitValue[1], { id: splitValue[3] });
        } else if (splitValue[2] == ".") {
            treeViewBaseElement = new Node(splitValue[1], { className: splitValue[3] });
        }
        document.body.appendChild(treeViewBaseElement.element);
        return treeViewBaseElement;
    }

    return {
        treeView: treeView,
    };
})();

var treeView = controls.treeView("div.tree-view");
var jsnode = treeView.addNode();
jsnode.content("JavaScript");
var js1subnode = jsnode.addNode();
js1subnode.content("JavaScript - part 1");
var js2subnode = jsnode.addNode();
js2subnode.content("JavaScript - part 2");
var jslibssubnode = jsnode.addNode();
jslibssubnode.content("JS Libraries");
var jsframeworksnode = jsnode.addNode();
jsframeworksnode.content("JS Frameworks and UI");
var webnode = treeView.addNode();
webnode.content("Web");