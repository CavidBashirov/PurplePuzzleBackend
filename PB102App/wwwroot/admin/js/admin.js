document.querySelector(".delete-category").addEventListener("click", function () {

    let categoryId = parseInt(this.getAttribute("data-id"));
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {

            fetch(`/admin/category/delete?id=${categoryId}`, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json, text/plain, */*',
                    'Content-Type': 'application/json'
                },
            }).then(res => res.json())
                .then(res => {
                    
                    Swal.fire({
                        title: "Deleted!",
                        text: "Your file has been deleted.",
                        icon: "success"
                    });
                });

            document.querySelector(`button[data-id = "${categoryId}"]`).parentNode.parentNode.remove();

           
        }
    });
})

