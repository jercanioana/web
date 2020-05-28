function addMove(id,userid, name){
    $.get("MovesController",
        {
            action:"add",
            id: id,
            userid: userid,
            name: name
        }
        );
}

function updateTime(id, time){
    $.post("MovesController",
        {
            action:"update",
            id:id,
            time:time
        })
}

function destroySession() {
    $.post("LoginController",
        {
            action:"logout",

        })

}