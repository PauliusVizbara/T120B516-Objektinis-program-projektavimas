"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/gameFlow").configureLogging(signalR.LogLevel.Trace).build();
connection.start()


document.getElementById('start-game-button').addEventListener("click", (e) => {
    connection.invoke("StartGame")
})


connection.on('GameStatus', (data) => {
    document.getElementById('start-game-button').classList.add('hide')
    const monsterList = data.monsterList
    const deadMonstersList = data.deadMonstersList

    deadMonstersList.forEach(monster => {
        const { monsterIndex: id } = monster 
        if (monsters[id]){
            monsters[id].remove()
            delete monsters[id]
         }
    })

    monsterList.forEach(monster => {
        const { monsterIndex: id, xCoordinate, currentHealth, yCoordinate, monsterType } = monster
        console.log(monster)
        if (tiles[yCoordinate - 1] && tiles[yCoordinate - 1][xCoordinate - 1]) {
            if (!monsters[id]) {
                console.log(`monster${monsterType}`)
                monsters[id] = new Entity({
                    currentHealth,
                    tile: tiles[xCoordinate - 1][yCoordinate - 1], sprite: sprites[`monster${monsterType}`],
                    onClick: () => uiManager.showMonsterMenu(monster)
                })
                monsters[id].render()
            }
            else {
                monsters[id].setHealth(currentHealth)
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
