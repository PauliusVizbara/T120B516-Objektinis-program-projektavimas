"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/testHub").build();

connection.start()


connection.on("ReceiveMessage", (x, y, unitType) => {
    document.getElementById(`${x}-${y}`).classList.toggle(unitType)
    document.getElementById(`${x}-${y}`).classList.toggle('occupied')
})


const unitSelectors = Array.from(document.getElementById("unit-selector").children)


unitSelectors.forEach(selector => {

    selector.addEventListener("click", (e) => {
        unitSelectors.forEach(selector => selector.classList.remove('active'))
        selector.classList.add('active')
        e.preventDefault()
    })

})

Array.from(document.getElementById("game-grid").children).forEach(cell => {
    cell.addEventListener("click", (e) => {
        const type = unitSelectors.find(el => el.classList.contains('active')).id
        console.log(type)
        const coordinates = cell.id.split('-')
        connection.invoke("SendMessage", coordinates[0], coordinates[1], type)
        e.preventDefault()
    })

})