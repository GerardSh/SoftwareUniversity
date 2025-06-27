let connection = new signalR.HubConnectionBuilder()
    .withUrl("/coffeehub")
    .build();

connection.on("ReceiveOrderUpdate", (update) => {
    document.getElementById("status").innerHTML = update;
});

connection.on("NewOrder", function (order) {
    document.getElementById("status").innerHTML = "Someone ordered a " + order.size + " " + order.product;
});

connection.on("Finished", function () {
    // document.getElementById("status").innerHTML = "Order processing finished!";
    // connection.stop();
});

connection.on("GetUpdateForOrder", function (message) {
    console.log("Update from server:", message);
    document.getElementById("status").innerText = message;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("submit").addEventListener("click", e => {
    e.preventDefault();

    const product = document.getElementById("product").value;
    const size = document.getElementById("size").value;

    fetch("/Coffee", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ product, size })
    })
        .then(response => response.text())
        .then(id => {
            connection.invoke("GetUpdateForOrder", parseInt(id));
        })
        .catch(err => console.error(err));
});
