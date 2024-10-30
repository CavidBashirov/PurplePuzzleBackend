let showMoreBtn = document.querySelector(".show-more");

showMoreBtn.addEventListener("click", async function () {
    let skip = parseInt(this.previousElementSibling.children.length);

    let response = await getDataAsync();

})


async function getDataAsync() {
    let response = await fetch('work/showmore?skip=1');
    let result = await response.text();
    return result;
    
}