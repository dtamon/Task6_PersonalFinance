import AccountService from "../../services/AccountService"
import React, { useState } from 'react'
import { Button, Form, Modal } from "react-bootstrap"
import { useUser } from "../../context/UserContext"
import jwt_decode from "jwt-decode"

export function LoginModal({ isOpenLoginForm }) {
    const accountService = new AccountService()
    const {
        setUser,
        closeLoginForm,
        openRegisterForm,
        setUserName,
        setPassword,
        userName,
        password,
    } = useUser()
    const [error, setError] = useState()

    function handleSubmit(e) {
        e.preventDefault()
        login()
    }

    return (
        <Modal show={isOpenLoginForm} onHide={closeLoginForm} centered>
            <Form onSubmit={handleSubmit}>
                <Modal.Header closeButton>
                    <Modal.Title variant="center">Sign In</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form.Group className="mb-3">
                        <Form.Label>Username</Form.Label>
                        <Form.Control type="text" required onChange={e => setUserName(e.target.value)} value={userName} />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" required onChange={e => setPassword(e.target.value)} value={password} />
                        <Form.Text className="text-danger">{error}</Form.Text>
                    </Form.Group>
                    <div className="text-center">
                        <Button variant="primary mb-3" type="submit">
                            Sign In
                        </Button>
                        <p>Not a member?<Button variant="link" onClick={() => { closeLoginForm(); openRegisterForm(); }}>Register</Button></p>
                    </div>
                </Modal.Body>
            </Form>
        </Modal>
    )

    async function login() {
        await accountService.loginUser(userName, password)
            .then(res => {
                if (!res.ok) res.text().then((value) => setError(value))
                else {
                    closeLoginForm()
                    setError()
                    return res.text()
                }
            })
            .then((result) => {
                const decodedToken = jwt_decode(result)
                setUser({
                    token: result,
                    userName: decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
                })
            }, (error) => {
                alert(error)
            })
    }
}
