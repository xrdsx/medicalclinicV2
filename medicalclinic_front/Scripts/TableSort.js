const table = document.querySelector("#MainContent_UserTable")
const headerCells = document.querySelectorAll("#MainContent_UserTable tbody tr th")
const searchInput = document.querySelector("#search-input")
const checkBoxes = document.getElementsByClassName("check-box")
const firstNameFilter = document.querySelector("#cb-firstname")
const surNameFilter = document.querySelector("#cb-secondname")

const rows = [];

for (let i = 1; i < table.tBodies[0].children.length; i++)
    rows.push(table.tBodies[0].children[i])

function checkIsActive() {

    let state = false;
    for (const el of table.tBodies[0].children) {
        console.log(el.children[7])
        if (el.children[5].textContent == 'True') {
            el.children[7].firstElementChild.textContent = "Deactivate";
            //state = true;
        }
            
        if (el.children[5].textContent == 'False') {
            el.children[7].firstElementChild.textContent = "Activate";  
            //state = true
        }                
    }
    //if(!state)
        //window.location.reload(true);
}

function sortTableByColumn(table, column, asc = true) {
    const dirModifier = asc ? 1 : -1;
    const rows = [];
    const tHead = table.tBodies[0].children[0];
    const tBody = table.tBodies[0];

    for (let i = 1; i < table.tBodies[0].children.length; i++)
        rows.push(table.tBodies[0].children[i])

    const sortedRows = rows.sort((a, b) => {
        const aColText = a.querySelector(`td:nth-child(${column+1})`).textContent.toLowerCase().trim();
        const bColText = b.querySelector(`td:nth-child(${column + 1})`).textContent.toLowerCase().trim();

        return aColText > bColText ? (1 * dirModifier) : (-1 * dirModifier)
    })

    while (tBody.rows.length != 1) {
        tBody.removeChild(tBody.lastChild)
    }

    tBody.append(...sortedRows)

    table.querySelectorAll("th").forEach(th => th.classList.remove("th-sort-asc", "th-sort-desc"))
    table.querySelector(`th:nth-child(${column + 1})`).classList.toggle("th-sort-asc", asc);
    table.querySelector(`th:nth-child(${column + 1})`).classList.toggle("th-sort-desc", !asc);

}

headerCells.forEach(headerCell => {
    headerCell.addEventListener('click', () => {
        const tableElement = headerCell.parentElement.parentElement.parentElement
        const headerIndex = Array.prototype.indexOf.call(headerCell.parentElement.children, headerCell)
        const currentIsAscending = headerCell.classList.contains('th-sort-asc');

        sortTableByColumn(tableElement, headerIndex, !currentIsAscending)
    })
})

function checkFiltering() {


    if (firstNameFilter.checked)
        return 'td:nth-child(3)';
    else if (surNameFilter.checked)
        return 'td:nth-child(4)'
    
}

searchInput.addEventListener('keyup', e => {
    rows.forEach(row => {
        if (firstNameFilter.checked && surNameFilter.checked) {

            const name = row.querySelector('td:nth-child(3)').textContent.toLowerCase()
            const surname = row.querySelector('td:nth-child(4)').textContent.toLowerCase()

            const word = name + ' ' + surname;

            word.indexOf(e.target.value) !== -1
                ? (row.style.display = 'table-row')
                : (row.style.display = 'none')
        }

        else if (firstNameFilter.checked) {
            row.querySelector('td:nth-child(3)').textContent.toLowerCase().indexOf(e.target.value) !== -1
                ? (row.style.display = 'table-row')
                : (row.style.display = 'none')
        }

        else if (surNameFilter.checked) {
            row.querySelector('td:nth-child(4)').textContent.toLowerCase().indexOf(e.target.value) !== -1
                ? (row.style.display = 'table-row')
                : (row.style.display = 'none')
        }

    })
})

checkIsActive()
table.addEventListener('click', checkIsActive) 