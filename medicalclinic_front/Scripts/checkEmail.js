const emailInput = document.querySelector('#email');
const btnSubmit = document.querySelector('#Button1');

const emailCheck = () => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (re.test(emailInput.value)) {
        btnSubmit.removeAttribute('disabled');
        btnSubmit.classList.remove('check-email');
    } else {
        btnSubmit.setAttribute('disabled', 'disabled');
        btnSubmit.classList.add('check-email');
    }
}
emailInput.addEventListener('keyup', emailCheck)