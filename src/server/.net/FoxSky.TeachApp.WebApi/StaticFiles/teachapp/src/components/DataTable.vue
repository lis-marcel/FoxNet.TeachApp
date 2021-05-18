<template>
    <div id="myTable">
    </div>
</template>

<script>
    var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                    var users = JSON.parse(this.responseText);

                var table = "<table>";
                for (var i = 0; i < users.length; i++) {
                    table += `<tr><td>${users[i].userId}</td><td>${users[i].surname}</td><td>${users[i].forename}</td></tr>`;
                }
                table += "</table>";
                document.getElementById("myTable").innerHTML = table;
            }
        };
        xmlhttp.open("GET", "/webapi/administration/user/all", true);
        xmlhttp.send();
</script>

<!--onclick="deleteUser(${users[i].userId})-->

<style>
</style>