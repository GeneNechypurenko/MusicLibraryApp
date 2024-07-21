document.addEventListener('DOMContentLoaded', function () {
    const deleteLinks = document.querySelectorAll('.delete-link');
    deleteLinks.forEach(link => {
        link.addEventListener('click', function (event) {
            event.preventDefault();
            const tuneId = this.getAttribute('data-id');
            $('#deleteConfirmModal').modal('show');

            document.getElementById('confirmDelete').onclick = async function () {
                $('#deleteConfirmModal').modal('hide');

                const response = await fetch(`/Home/Delete/${tuneId}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                        'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                    }
                });

                if (response.ok) {
                    $('#deleteSuccessModal').modal('show');
                } else {
                    alert('Something went wrong!');
                }
            };
        });
    });
});

$(document).ready(function () {
    $('.btn[data-dismiss="modal"]').click(function () {
        $(this).closest('.modal').modal('hide');
    });
});
