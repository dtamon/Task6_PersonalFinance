import { Button, Container, Nav, Navbar as NavbarBs } from 'react-bootstrap'
import { NavLink } from 'react-router-dom'
import React from 'react'
import { useUser } from '../context/UserContext'

export function Navbar() {
    const { openLoginForm } = useUser()
    return (
        <NavbarBs sticky='top' className='bg-white shadow-sm shadow mb-3'>
            <Container>
                <Nav className='me-auto fs-5'>
                    <Nav.Link to="/" as={NavLink}>
                        Summary
                    </Nav.Link>
                    <Nav.Link to="/incomes" as={NavLink}>
                        Incomes
                    </Nav.Link>
                    <Nav.Link to="/expenses" as={NavLink}>
                        Expenses
                    </Nav.Link>
                </Nav>
                <Button
                    onClick={openLoginForm}
                >
                    Sign in
                </Button>
            </Container>
        </NavbarBs>
    )
}
