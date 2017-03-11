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
    },
    GetMethodByAJAX:function() {
        
    },
    PostMethodByAJAX:function () {
        
    },
    AJAXProcessMethod:function (method,url,params,callBackfunc) {
        var xhrer=this.XmlHttpRequester();
        var HttpMethod=method.toLowerCase();
        xhrer.open(method,url,true);
        if (HttpMethod=="get") {
            xhrer.setRequestHeader("If-Modified-Since","0");
        }
        if (HttpMethod=="post") {
            xhrer.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        }
        xhrer.onreadystatechange=function () {
                
        }
    }

}
