PIXI.utils.skipHello();

var app = new PIXI.Application({
    backgroundColor: 0x11151C,
    antialias: false,
    autoDensity: true,
    resolution: 1
})

const viewport = new Viewport.Viewport({
    screenWidth: window.innerWidth,
    screenHeight: window.innerHeight,
    worldWidth: 1000,
    worldHeight: 1000,
    interaction: app.renderer.plugins.interaction // the interaction module is important for wheel to work properly when renderer.view is placed or scaled
})

app.stage.addChild(viewport)
viewport.drag().wheel()
document.body.appendChild(app.view)

app.renderer.resize(window.innerWidth, window.innerHeight)
window.addEventListener("resize", function () {
    app.renderer.resize(window.innerWidth, window.innerHeight)
})

const stage = app.stage
const mapSize = 15
const cellSize = 40
const cellHeight = 4
let startingX = 600
let startingY = 40
const tiles = Array(mapSize).fill().map(() => Array(mapSize).fill())
const monsters = {}
const towers = {}
const pathTiles = [
    {x: 0, y: 1}, {x: 1, y: 1},
    {x: 2, y: 1}, {x: 3, y: 1},
    {x: 4, y: 1}, {x: 5, y: 1},
    {x: 6, y: 1}, {x: 7, y: 1},
    {x: 7, y: 2}, {x: 7, y: 3},
    {x: 7, y: 4}, {x: 8, y: 4},
    {x: 9, y: 4}, {x: 10, y: 4},
    {x: 11, y: 4}, {x: 12, y: 4},
    {x: 13, y: 4}, {x: 14, y: 4},
]

const waterTiles = [
    { x: 1, y: 10 }, { x: 2, y: 10 },
    { x: 3, y: 10 }, { x: 4, y: 10 },
    { x: 2, y: 11 }, { x: 3, y: 11 },
    { x: 2, y: 11 }, { x: 3, y: 11 },
    { x: 3, y: 9 },
]

const obstacles = [
    { x: 10, y: 10, sprite: sprites.tree},
    { x: 11, y: 8, sprite: sprites.tree},
    { x: 13, y: 10, sprite: sprites.tree},
    { x: 7, y: 9, sprite: sprites.tree },
    { x: 2, y: 11, sprite: sprites.ship1}
]

for (let cellX = 0; cellX < mapSize; cellX++) {
    for (let cellY = 0; cellY < mapSize; cellY++) {
        const X = startingX - cellY * cellSize
        const Y = startingY + ((cellSize + cellHeight) / 2) * cellY
        let tileType = 'ground'
        if (pathTiles.find(({ x, y }) => cellY === y && cellX === x)) tileType = 'path'
        if (waterTiles.find(({ x, y }) => cellY === y && cellX === x)) tileType = 'water'
        const tileBuilder = new TileBuilder()
        tileBuilder.startNew({ x: cellX, y: cellY, stage: stage, tileRenderPoint: { x: X, y: Y } })
        tileBuilder.addTileType(tileType)
        const obstacle = obstacles.find(({ x, y }) => cellY === y && cellX === x)
        if (obstacle) tileBuilder.addObstacle(obstacle.sprite)
        tiles[cellX][cellY] = tileBuilder.build()
    }
    startingX += cellSize
    startingY += ((cellSize + cellHeight) / 2)
}

for (let i = 0; i < tiles.length; i++) {
    for (let j = 0; j < tiles[i].length; j++) {
        tiles[i][j].render()
    }
}

const uiManager = new UIManager(document.getElementById('ui-container'))



//new Entity({ tile: tiles[1][1], sprite: sprites.monster3 }).render()
//new Entity({ tile: tiles[3][1], sprite: sprites.monster1 }).render()

//new Entity({ tile: tiles[6][6], sprite: sprites.archerTower, onClick: () => { uiManager.showTowerInfoMenu({})}}).render()
