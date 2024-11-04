//let showMoreBtn = document.querySelector(".show-more");

//showMoreBtn.addEventListener("click", async function () {
//    let skip = parseInt(this.previousElementSibling.children.length);

//    let response = await getDataAsync();

//})


//async function getDataAsync() {
//    let response = await fetch('work/showmore?skip=1');
//    let result = await response.text();
//    return result;

//}


let elems = document.querySelectorAll(".add-to-basket");

elems.forEach(elem => {

    elem.addEventListener("click", function () {

        let workId = parseInt(this.getAttribute("data-id"));

        fetch(`home/AddWorkToBasket?id=${workId}`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
        }).then(res => res.json())
            .then(res => {
                document.querySelector(".cart-count").innerText = res;
                Swal.fire({
                    position: "top-end",
                    icon: "success",
                    title: "Your work has been successfully added",
                    showConfirmButton: false,
                    timer: 1500
                });
            });

    })
});




