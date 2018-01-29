function doTheAction() {
    var p1 = { id: 101, name: 'Product-101', price: 99 };

    var jsonString = JSON.stringify(p1);
    document.writeln(jsonString);
    var p1Back =JSON.parse(jsonString);
    document.writeln(p1Back.id + ') ' + p1Back.name + ', Price: ' + p1Back.price);
}

doTheAction();