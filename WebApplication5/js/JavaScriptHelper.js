var JsHelper = {

};
var jsonSerializerInAJAX = {
    XmlHttpRequester: function () {
        var xhrer;
        if (window.XMLHttpRequest()) {
            xhrer = new XMLHttpRequest();
        } else {
            xhrer =new ActiveXObject("Microsoft.XMLHTTp");
        }
        return xhrer;
    }

}