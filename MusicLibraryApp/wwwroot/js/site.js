document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.delete-link').forEach(function (link) {
        link.addEventListener('click', function (event) {
            event.preventDefault();
            var itemId = this.getAttribute('data-id');
            var controller = this.getAttribute('data-controller');
            $('#deleteConfirmModal').data('itemId', itemId).data('controller', controller).modal('show');
        });
    });

    document.getElementById('confirmDelete').addEventListener('click', function () {
        var itemId = $('#deleteConfirmModal').data('itemId');
        var controller = $('#deleteConfirmModal').data('controller');

        $('#deleteConfirmModal').modal('hide');

        $.ajax({
            url: '/' + controller + '/Delete/' + itemId,
            type: 'DELETE',
            headers: {
                'X-Requested-With': 'XMLHttpRequest'
            },
            success: function (result) {
                $('#deleteSuccessModal').modal('show');
                $('#item-' + itemId).remove();
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
            }
        });
    });
});

$(document).ready(function () {
    $('.btn[data-dismiss="modal"]').click(function () {
        $(this).closest('.modal').modal('hide');
    });
});
