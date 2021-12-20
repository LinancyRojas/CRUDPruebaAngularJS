var MiApp = angular.module("Homeapp", []);

MiApp.controller("HomeController", function ($scope, $http) {

    /* Guarda y Actualiza Usuario */
    $scope.Guardar = function () {

        var id = $scope.Id;

        if (id == 0) {
            var saveReq = {
                method: "POST",
                url: "/Home/Guardar",
                data: { Id: 1, name: $scope.name, email: $scope.email, password: $scope.password, contrycode: $scope.contrycode, citycode: $scope.citycode, number: $scope.number }
            }

            $http(saveReq).then(function (mRes) {
                var o = angular.fromJson(mRes.data)
                alert("Usuario Guardado con éxito");
                $scope.Listar();
            });
        }
        else {
            var updateReq = {
                method: "POST",
                url: "/Home/Actualizar",
                data: { Id: $scope.Id, name: $scope.name, email: $scope.email, password: $scope.password, contrycode: $scope.contrycode, citycode: $scope.citycode, number: $scope.number }
            }

            $http(updateReq).then(function (mRes) {
                var o = angular.fromJson(mRes.data)
                alert("Usuario Actualizado con éxito");
                $scope.Listar();
            });
        }

        $scope.ClearControls();
    };

    /* Obtiene Usuario por Id */
    $scope.ObtenerPorId = function (id) {

        if (id > 0) {
            var getReq = {
                method: "POST",
                url: "/Home/ObtenerPorId",
                data: { Id: id }
            }

            $http(getReq).then(function (mRes) {
                $scope.Usuario = angular.fromJson(mRes.data);

                console.log($scope.Usuario);

                $scope.Id = $scope.Usuario.Id;
                $scope.name = $scope.Usuario.name;
                $scope.email = $scope.Usuario.email;
                $scope.number = $scope.Usuario.number;
                $scope.citycode = $scope.Usuario.citycode;
                $scope.contrycode = $scope.Usuario.contrycode;
            });
        } else {
            alert("No existe registro para Actualizar");
        }
        
    };

    /* Obtiene la lista de usuarios */
    $scope.Listar = function () {
        var getallReq = {
            method: "POST",
            url: "/Home/Listar",
            data: {}
        }

        $http(getallReq).then(function (mRes) {
            if (mRes.data != "") {
                $scope.UsuarioData = angular.fromJson(mRes.data);
            }
            else {
                $scope.UsuarioData = "";
            }
        });
    };

    $scope.Listar();

    /* Elimina un usuario */
    $scope.Eliminar = function (id) {

        if (id > 0) {
            var updateReq = {
                method: "POST",
                url: "/Home/Eliminar",
                data: { Id: id }
            }

            $http(updateReq).then(function (mRes) {
                //var o = angular.fromJson(mRes.data)
                alert("Usuario Eliminado con éxito");
                $scope.Listar();
            });
        } else {
            alert("No existe registro para eliminar");
        }
        
    };

    /*Limpia los objetos HTML */
    $scope.ClearControls = function () {
        $scope.Id = 0;
        $scope.name = '';
        $scope.email = '';
        $scope.password = '';
        $scope.contrycode = '';
        $scope.citycode = '';
        $scope.number = '';
    }

});