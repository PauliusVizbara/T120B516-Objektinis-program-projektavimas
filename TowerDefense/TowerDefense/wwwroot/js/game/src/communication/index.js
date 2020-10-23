"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/gameFlow").build();
connection.start()


document.getElementById('start-game-button').addEventListener("click", (e) => {
    connection.invoke("StartGame")
})


connection.on('GameStatus', (data) => {
    document.getElementById('start-game-button').classList.add('hide')
    const monsterList = data.monsterList

    monsterList.forEach(monster => {
        const { monsterIndex: id, xCoordinate, yCoordinate } = monster

        if (tiles[yCoordinate - 1] && tiles[yCoordinate - 1][xCoordinate - 1]) {
            if (!monsters[id]) {
                monsters[id] = new Entity({
                    tile: tiles[xCoordinate - 1][yCoordinate - 1], sprite: sprites.monster1,
                    onClick: () => uiManager.showMonsterMenu(monster)
                })
                monsters[id].render()
            }
            else {
                monsters[id].move(tiles[xCoordinate - 1][yCoordinate - 1])
            }
        }
    })
})


const requestTowerBuild = (x, y, towerType) => {
    connection.invoke("RequestBuildTower", x, y, towerType)
}



connection.on('BuildTower', (x, y, data) => {
    console.log(data, sprites[data.name])
    const tower = new Entity({
        tile: tiles[x][y], sprite: sprites[data.name],
        onClick: () => uiManager.showTowerInfoMenu({ x, y, ...data })
    })
    tower.render()
})
