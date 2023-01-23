import AccountService from "../services/AccountService"
import React, { useState } from 'react'
import { Button, Form, Modal } from "react-bootstrap"
import { useUser } from "../context/UserContext"

export function LoginModal({ isOpenLoginForm }) {
    const accountService = new AccountService()
    const {
        setUser,
        closeLoginForm,
        openRegisterForm,
        setUserName,
        setPassword,
        user,
        userName,
        password,
    } = useUser()
    const [error, setError] = useState()

    function handleSubmit(e) {
        e.preventDefault()
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
}
