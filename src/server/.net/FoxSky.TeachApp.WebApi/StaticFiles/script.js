function showMessage(message) {
    var div = document.getElementById('error');
    div.innerHTML = message;
}
 
function updateButtons() {
    var id = document.getElementById('id').value;

    var validId = (id != "" && id != null && parseInt(id));
    document.getElementById('show').disabled = !validId;
    document.getElementById('edit').disabled = !validId;
}

function deleteUser(id) {
    showMessage("");

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            loadAllUsers();
        }
    };

    xmlhttp.open("POST", `/webapi/administration/user/delete/${id}`, true);
    xmlhttp.send();
}

function loadAllUsers() {
    showMessage("");

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
             var users = JSON.parse(this.responseText);

            var table = "<table>";
            for (var i = 0; i < users.length; i++) {
                table += `<tr><td>${users[i].userId}</td><td>${users[i].surname}</td><td>${users[i].forename}</td><td><button onclick="deleteUser(${users[i].userId})">Delete</button></td></tr>`;
            }
            table += "</table>";
            document.getElementById("myTable").innerHTML = table;
        }
    };
    xmlhttp.open("GET", "/webapi/administration/user/all", true);
    xmlhttp.send();
}

function showUser() {
    showMessage("");

    var id = document.getElementById('id').value;
    var ctrlForename = document.getElementById('Forename').value;
    var ctrlSurname = document.getElementById('Surname').value;

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4) {
            if (this.status == 200) {
                var user = JSON.parse(this.responseText);
                document.getElementById('Forename').value = user.forename;
                document.getElementById('Surname').value = user.surname;
            } else {
                showMessage(`Could not load data from server for id: ${id}, status: ${this.status}`);
            }
        }
    };
    xmlhttp.open("GET", `/webapi/administration/user/get/${id}`, true);
    xmlhttp.send();
}

function updateUser() {
    showMessage("");

    var user = {
        userId: null,
        surname: null,
        forename: null
    };

    user.userId = document.getElementById('id').value;
    
    if (user.userId != null && user.userId != "") {
        user.forename = document.getElementById('Forename').value;
        user.surname = document.getElementById('Surname').value;

        var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                loadAllUsers();
            }
        };

        xmlhttp.open("POST", `/webapi/administration/user/edit`, true);
        xmlhttp.setRequestHeader("Content-type", "application/json");
        xmlhttp.send(JSON.stringify(user));
    } else {
        showMessage("Could not update, the reason: unknown ID");
    }
}

function addUser() {
    showMessage("");

    var ctrlForename = document.getElementById('Forename');
    var ctrlSurname = document.getElementById('Surname');

    var user = {
        surname: null,
        forename: null
    };

    user.forename = ctrlForename.value;
    user.surname = ctrlSurname.value;

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
           ctrlForename.value = null;
           ctrlSurname.value = null;
           //loadAllUsers();
        }
    };

    xmlhttp.open("POST", `/webapi/administration/user/add`, true);
    xmlhttp.setRequestHeader("Content-type", "application/json");
    xmlhttp.send(JSON.stringify(user));
}