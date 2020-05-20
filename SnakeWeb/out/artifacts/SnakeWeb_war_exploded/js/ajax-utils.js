function addMove(id, name){
    $.get("MovesController",
        {
            action:"add",
            id: id,
            name: name
        }
        );

}