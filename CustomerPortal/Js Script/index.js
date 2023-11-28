
$(document).ready(function () {
    $.ajax({
        url: '@Url.Action("Details", "Home")',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            renderCustomerDetails(data);
        },
        error: function () {
            alert('Session Expired Please Relogin');
        }
    });

    function renderCustomerDetails(data) {
        var detailsContainer = $('#customer-details');
        detailsContainer.empty();

        if (data.length > 0) {
            $.each(data, function (index, customer) {
                var html = '<tr>';
                html += '<td>' + customer.CustomerName + '</td>';
                html += '<td>' + customer.CustomerEmail + ' <a href="#" class="edit-link"><i class="fas fa-edit"></i></a></td>';
                html += '<td>' + customer.CustomerPhone + ' <a href="#" class="edit-link"><i class="fas fa-edit"></i></a></td>';
                html += '</tr>';
                detailsContainer.append(html);
            });
        } else {
            detailsContainer.html('No customer details found.');
        }
    }

    $(document).on('click', '.edit-link', function (e) {
        e.preventDefault();
        editModal.style.display = 'block';
    });
});
function closeModal() {
    var editModal = document.getElementById('editModal');
    var mailInput = editModal.querySelector('#Mail');
    mailInput.value = '';
    editModal.style.display = 'none';
}


$(document).ready(function () {
    $('#savebtn').click(function () {
        var mail = document.getElementById('Mail').value;
        if (mail.trim() === '') {
            alert('Enter mail Id');
            return false;
        } else {
            $.ajax({
                type: 'POST',
                url: '@Url.Action("SaveMail", "Home")',
                data: { email: mail },
                success: function (response) {
                    if (response.success) {
                        alert('Record saved');
                    } else {
                        alert('Failed to save record');
                    }
                },
                error: function () {
                    alert('An error occurred while saving the record');
                }
            });
        }
    });
});
