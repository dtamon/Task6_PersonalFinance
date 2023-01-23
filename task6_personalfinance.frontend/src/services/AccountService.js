export default class AccountService {
    async loginUser(userName, password) {
        const response = await fetch('/api/account/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                userName: userName,
                password: password,
            })
        })
        return response;
    }

    async registerUser(userName, email, password, confirmPassword) {
        const response = await fetch('/api/account/register', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                userName: userName,
                email: email,
                password: password,
                confirmPassword: confirmPassword
            })
        })
        return response;
    }
}