var JsHelper = {

};
var jsonSerializerInAJAX = {
    //创建一个异步对象；
    XmlHttpRequester: function () {
        var xhrer;
        if (window.XMLHttpRequest()) {
            xhrer = new XMLHttpRequest();
        } else {
            xhrer =new ActiveXObject("Microsoft.XMLHTTp");
        }
        return xhrer;
    },
    //get请求的异步对象处理方法；
    GetMethodByAJAX: function (url, callBackfunc) {
        AJAXProcessMethod("get", url, null, callBackfunc);
    },
    //post请求的异步对象处理方法；
    PostMethodByAJAX: function (url, params, callBackfunc) {
        AJAXProcessMethod("post", url, params, callBackfunc);
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
        xhrer.onreadystatechange = function () {
            var results = xhrer.responseText;
            var jsons=JSON.parse(results);
            callBackfunc(jsons);
        }
        if (HttpMethod=="get")
        {
            xhrer.send(null);
        }
        if (HttpMethod=="post")
        {
            xhrer.send(params);
        }
    }

}
