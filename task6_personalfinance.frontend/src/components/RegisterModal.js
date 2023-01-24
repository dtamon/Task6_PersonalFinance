import AccountService from "../services/AccountService"
import React, { useState } from 'react'
import { Button, Form, Modal } from "react-bootstrap"
import { useUser } from "../context/UserContext"

export function RegisterModal({ isOpenRegisterForm }) {
    const accountService = new AccountService()
    const {
        closeRegisterForm,
        openLoginForm,
        setUserName,
        setEmail,
        setPassword,
        setConfirmPassword,
        userName,
        email,
        password,
        confirmPassword
    } = useUser()

    const [userNameError, setUserNameError] = useState()
    const [emailError, setEmailError] = useState()
    const [passwordError, setPasswordError] = useState()
    const [confirmPasswordError, setconfirmPasswordError] = useState()

    function handleSubmit(e) {
        e.preventDefault()
        register()
    }

    return (
        <Modal show={isOpenRegisterForm} onHide={closeRegisterForm} centered>
            <Form onSubmit={handleSubmit}>
                <Modal.Header closeButton>
                    <Modal.Title variant="center">Sign Up</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form.Group className="mb-3">
                        <Form.Label>Username</Form.Label>
                        <Form.Control type="text" required onChange={e => setUserName(e.target.value)} value={userName} />
                        <Form.Text className="text-danger">{userNameError}</Form.Text>
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" required onChange={e => setEmail(e.target.value)} value={email} />
                        <Form.Text className="text-danger">{emailError}</Form.Text>
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" required onChange={e => setPassword(e.target.value)} value={password} />
                        <Form.Text className="text-danger">{passwordError}</Form.Text>
                    </Form.Group><Form.Group className="mb-3">
                        <Form.Label>Confirm Password</Form.Label>
                        <Form.Control type="password" required onChange={e => setConfirmPassword(e.target.value)} value={confirmPassword} />
                        <Form.Text className="text-danger">{confirmPasswordError}</Form.Text>
                    </Form.Group>
                    <div className="text-center">
                        <Button variant="primary mb-3" type="submit">
                            Sign Up
                        </Button>
                        <p>Already have an account?<Button variant="link" onClick={() => { closeRegisterForm(); openLoginForm(); }}>Sign In</Button></p>
                    </div>
                </Modal.Body>
            </Form>
        </Modal>
    )

    async function register() {
        await accountService.registerUser(userName, email, password, confirmPassword)
            .then(res => res.text())
            .then(body => {
                try {
                    return JSON.parse(body)
                } catch {
                    return body
                }
            })
            .then((result) => {
                if (result.errors !== undefined) {
                    result.errors.UserName !== undefined ? setUserNameError(result.errors.UserName[0]) : setUserNameError()
                    result.errors.Email !== undefined ? setEmailError(result.errors.Email[0]) : setEmailError()
                    result.errors.Password !== undefined ? setPasswordError(result.errors.Password[0]) : setPasswordError()
                    result.errors.ConfirmPassword !== undefined ? setconfirmPasswordError(result.errors.ConfirmPassword[0]) : setconfirmPasswordError()
                } else {
                    openLoginForm()
                    closeRegisterForm()
                    resetForm()
                    alert(result)
                }
            }, (error) => {
                alert(error)
            })

    }

    function resetForm() {
        setConfirmPassword()
        setEmailError()
        setPasswordError()
        setconfirmPasswordError()
    }
}
