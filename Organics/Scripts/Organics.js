function product(Id, Name, Description, AddDate,UpdateDate, Price, sendProductToServer) {
    var self = this;
    
    self.addProduct = function () {
        products.push(this);
        $.ajax({
            url: '/api/productapi/',
            type: 'post',
            data: ko.toJSON(this),
            contentType: 'application/json',
            success: function (result) {
               
            }

        });
    }
    self.deleteProduct = function () {
        products.remove(this);
        $.ajax({
            url: '/api/productapi/' + this.ID,
            type: 'delete',
            data: {},
            contentType: 'application/json',
            success: function (result) {                
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


function getProducts() {
    self.products.removeAll();
    $.getJSON("api/productapi/", function (data) {
        $.each(data, function (key, val) {
            self.products.push(new product(val.ID, val.name, val.description,val.addDate,val.updateDate,val.price));
        });
    });
}

var products = ko.observableArray([]);

$(document).ready(function () {


    ko.applyBindings(products);

    CKEDITOR.replace("description");

});
    