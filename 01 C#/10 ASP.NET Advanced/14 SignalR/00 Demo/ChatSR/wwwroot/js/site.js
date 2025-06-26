var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    li.textContent = `${user} says: ${message}`;
    document.getElementById("messageHistory").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("user").value;
    var message = document.getElementById("message").value;

    connection.invoke("SendMessage", user, message).then(function () {
        document.getElementById("message").value = "";
    }).catch(function (err) {
        console.error(err.toString());
    });

    event.preventDefault();
});