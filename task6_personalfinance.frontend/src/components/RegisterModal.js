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
    const [error, setError] = useState()

    function handleSubmit(e) { }

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
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" required onChange={e => setEmail(e.target.value)} value={email} />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" required onChange={e => setPassword(e.target.value)} value={password} />
                    </Form.Group><Form.Group className="mb-3">
                        <Form.Label>Confirm Password</Form.Label>
                        <Form.Control type="password" required onChange={e => setConfirmPassword(e.target.value)} value={confirmPassword} />
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
}
