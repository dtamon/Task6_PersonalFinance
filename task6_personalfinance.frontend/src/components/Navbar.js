import { Button, Container, Nav, Navbar as NavbarBs } from 'react-bootstrap'
import { NavLink } from 'react-router-dom'
import React from 'react'
import { useUser } from '../context/UserContext'

export function Navbar() {
    const { user, setUser, openLoginForm } = useUser()
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
                {user !== undefined ?
                    <>
                        <h4 className='me-3'>Signed in as: {user.userName}</h4>
                        <Button
                            onClick={() => setUser()}
                            style={{ width: "3.6rem", height: "3.6rem", position: "relative" }}
                            variant="outline-none">
                            <svg
                                xmlns="http://www.w3.org/2000/svg"
                                fill="currentColor"
                                viewBox="0 0 16 16"
                                id="IconChangeColor">
                                <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" id="mainIconPathAttribute"></path>
                            </svg>
                        </Button>
                    </>
                    : <Button
                        onClick={openLoginForm}
                        style={{ width: "3.6rem", height: "3.6rem", position: "relative" }}
                        variant="outline-none">
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            fill="currentColor"
                            viewBox="0 0 16 16"
                            id="IconChangeColor">
                            <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" id="mainIconPathAttribute"></path>
                        </svg>
                    </Button>
                }
            </Container>
        </NavbarBs>
    )
}
