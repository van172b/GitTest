function product(Id, Name, Description, AddDate,UpdateDate, Price, sendProductToServer) {
    var self = this;
    
    self.addProduct = function () {
        $.ajax({
            url: '/api/productapi/',
            type: 'post',
            data: ko.toJSON(this),
            contentType: 'application/json',
            success: function (result) {
                alert(result);
            }

        });
    }
    self.deleteProduct = function () {
        $.ajax({
            url: '/api/productapi/' + this.ID,
            type: 'delete',
            data: {},
            contentType: 'application/json',
            success: function (result) {
                alert(result);
                productVModel.products.remove(this);
            }

        });
    }

    

    self.ID = Id;
    self.name = Name;
    self.description = Description;
    self.addDate = AddDate;
    self.updatedDate = UpdateDate;
    self.price = Price;
    if (sendProductToServer) {

        self.addProduct();

    }
}

function productVModel() {
    var self = this;
    self.products = ko.observableArray([]);
    self.getProducts = function () {
        self.products.removeAll();
        $.getJSON("api/productapi/", function (data) {
            $.each(data, function (key, val) {
                self.products.push(new product(val.ID, val.name, val.description,val.addDate,val.updateDate,val.price));
            });
        });
    }

}



$(document).ready(function () {
    ko.applyBindings(new productVModel());

    CKEDITOR.replace("description");
    //var p = new product(22,'test name','description of things','2/22/2009','3/22/2010',22.59);
    //p.addProduct();
    /*$.ajax({
        url: "/api/productapi/",
        data: ko.toJSON(null),
        contentType: 'application/json',
        success: function (result) {
            alert(result);
        }*/

});
    //, document.getElementById('displayNode'));
    //ko.applyBindings(new product(), document.getElementById('createNode'));
    //productVModel.getProducts();
//});