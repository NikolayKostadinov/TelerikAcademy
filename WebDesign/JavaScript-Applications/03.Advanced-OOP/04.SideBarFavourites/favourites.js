var favSiteBar = Class.create({
    init: function (wrapper) {
        this._folderContainer = [];
        this._wrapper = document.getElementById(wrapper);
        this._baseElement = {};
    },
    appendFolder: function (folder) {
        this._folderContainer.push(folder);
    },

    renderSiteBar: function () {
        this._baseElement = document.createElement("ul");

        for (var f = 0; f < this._folderContainer.length; f++) {
            var folder = this._folderContainer[f];
            var domFolder = folder.renderFolder();
            var domFolderHolder = document.createElement('li');
            var domFolderTitle = document.createElement('a');
            domFolderTitle.href = "#";
            domFolderTitle.innerHTML = folder._title;
            domFolderTitle.onclick = folder.onClick;
            domFolderTitle.style.backgroundImage = "url('/image/folderClosed.png')";
            domFolderTitle.style.backgroundSize = '25px 25px';
            domFolderTitle.style.backgroundPosition = '0, 0';
            domFolderTitle.style.backgroundRepeat = 'no-repeat';
            domFolderTitle.style.paddingLeft = '32px';
            domFolderTitle.style.lineHeight = '32px';
            domFolderHolder.appendChild(domFolderTitle);
            domFolderHolder.appendChild(domFolder);
            this._baseElement.appendChild(domFolderHolder);
        }

        this._wrapper.appendChild(this._baseElement);

    }
});

var node = Class.create({
    init: function (title) {
        this._title = title;
        this._elements = [];
        this._node = document.createElement("ul");
    },
});

var Folder = Class.create({
    init: function (title) {
        //this._super.init(title);
        this._baseElement = {};
        this._title = title;
        this._elements = [];
    },

    appendUrl: function (newUrl) {
        this._elements.push(newUrl)
    },

    renderFolder: function () {
        this._baseElement = document.createElement('ul');
        for (var u = 0; u < this._elements.length; u++) {
            var url = this._elements[u];
            var domUrl = url.renderUrl();
            this._baseElement.appendChild(domUrl);
        }
        this._baseElement.style.display = 'none';
        return this._baseElement;
    },

    onClick: function (ev) {
        if (this.style.backgroundImage == "url(\"/image/folderClosed.png\")") {
            this.style.backgroundImage = "url('/image/folderOpen.png')";
            var ul = this.parentNode.getElementsByTagName('ul')[0];
            ul.style.display = "block";
        } else {
            this.style.backgroundImage = "url('/image/folderClosed.png')";
            var ul = this.parentNode.getElementsByTagName('ul')[0];
            ul.style.display = "none";
        }
    }
});



var Url = Class.create({
    init: function (title, href) {
        //this._super.init(title);
        this._baseElement = document.createElement('li');
        this._title = title;
        this._elements = [];
        this.href = href;
    },

    renderUrl: function () {
        var domUrl = document.createElement('a');
        domUrl.href = this.href;
        domUrl.target = "_blank";
        domUrl.innerHTML = this._title;
        domUrl.style.backgroundImage = "url('/image/url.png')";
        domUrl.style.backgroundSize = '25px 25px';
        domUrl.style.backgroundPosition = '0, 0';
        domUrl.style.backgroundRepeat = 'no-repeat';
        domUrl.style.paddingLeft = '32px';
        domUrl.style.lineHeight = '32px';
        this._baseElement.appendChild(domUrl);

        return this._baseElement;
    }
});


var folders = [];

var fold = new Folder("My Favourites");
var url1 = new Url("Google", "http://www.google.bg");
fold.appendUrl(url1);
url1 = new Url("Zamunda", "http://zamunda.net/");
fold.appendUrl(url1);
url1 = new Url("LinkedIn", "http://www.linkedin.com/");
fold.appendUrl(url1);
url1 = new Url("Telerik Academy", "http://telerikacademy.com/");
fold.appendUrl(url1);
url1 = new Url("Forum Telerik", "http://forums.academy.telerik.com/");
fold.appendUrl(url1);

folders.push(fold);

for (var i = 1; i < 10; i++) {
    var folder = new Folder('folder' + (i + 1));
    folders.push(folder);
}

var tree = new favSiteBar('side-wrapper');

for (var f in folders) {
    tree.appendFolder(folders[f]);
}

tree.renderSiteBar();

