app.factory('AjaxService', function ($http, MVC_URL) {
    let serv = {
        get: function(getPath){
            return $http.get(MVC_URL + getPath);
        },

        post: function(postPath, data){
            return $http.post(MVC_URL + postPath, data);
        },

        deleteItem: function(deletePath, data){
            return $http.delete(MVC_URL + deletePath, data);
        }
    }

    return serv;
});