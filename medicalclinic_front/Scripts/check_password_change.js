const btn = document.querySelector('#Button1');
const btnCancel = document.querySelector('#returnBtn');
const pass = document.querySelector('#new_passw');
const confirmPass = document.querySelector('#confirm_passw');
const popup = document.querySelector('.popup');

const handleCancelBtn = e => {
    e.preventDefault();

    if (confirm('Czy na pewno chcesz opuścić ten formularz'))
        window.location.href = 'Login.aspx';
    else
        [pass, confirmPass].forEach(el => el.value = '');
}

const checkPassword = (pass1, pass2) => {
        if ((pass1.value !== pass2.value) || (pass1.value == '' && pass2.value == '')) {
            btn.classList.add('change-password');
            return false;
        }
        else {
            btn.classList.remove('change-password')
            return true;
        }
}

const handleSubmitBtn = e => {
    if (!checkPassword(pass, confirmPass))
        e.preventDefault();

    confirm('Hasła się zgadzają!');
}

[pass, confirmPass].forEach(el => el.addEventListener('keyup', function () {
    checkPassword(pass, confirmPass)
}))

btn.addEventListener('click', handleSubmitBtn)
btnCancel.addEventListener('click', handleCancelBtn)