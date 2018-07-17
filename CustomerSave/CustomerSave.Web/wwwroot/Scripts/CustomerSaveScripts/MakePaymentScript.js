function getByCustomerGivenId() {
    const customerGivenId = $('#CustomerGivenId').val();
    networkApi("/Customer/GetCustomerByGivenId", { customerGivenId }).then(result => {
        handleResponse(result, 'CustomerGivenId');
    }).catch(err => {
        showErrorMsg();
    });
}

function getByUsername() {
    const username = $('#Username').val();
    networkApi("/Customer/GetCustomerByUsername", { username }).then(result => {
        handleResponse(result, 'Username');
    }).catch(err => {
        showErrorMsg();
    });
}

function handleResponse(result, type) {
    if (result == null) {
        if (type === 'CustomerGivenId') $('#Username').val('');
        else if (type === 'Username') $('#CustomerGivenId').val('');
        $('#FirstName').val('');
        $('#LastName').val('');
        $('#submitBtn').prop('disabled', true);
        showErrorMsg('');
        return;
    }

    $('#CustomerGivenId').val(result.CustomerGivenId);
    $('#Username').val(result.Username);
    $('#FirstName').val(result.FirstName);
    $('#LastName').val(result.LastName);
    $('#submitBtn').prop('disabled', false);
    showSuccessMsg();
}

function showErrorMsg(msg = "Network Error Has Occured") {
    const msgSpan = $('.error-div');
    msgSpan.text(msg);
    msgSpan.removeClass('text-success');
    msgSpan.addClass('text-danger');
}

function showSuccessMsg(msg = "Customer found") {
    const msgSpan = $('.error-div');
    msgSpan.text(msg);
    msgSpan.removeClass('text-danger');
    msgSpan.addClass('text-success');
}

function networkApi(url, data, type = "GET"){
    return new Promise((resolve, reject) => {
        $.ajax({
            dataType: "json",
            url,
            type,
            data,
            success: result => resolve(result),
            error: err => reject(err)
        })
    });
}