import React, { useContext, useState } from "react"
import { LoginModal } from "../components/LoginModal"
import { RegisterModal } from "../components/RegisterModal"

const UserContext = React.createContext()

export function useUser() {
    return (
        useContext(UserContext)
    )
}

export const UserProvider = ({ children }) => {
    const [isOpenLoginForm, setIsOpenLoginForm] = useState(false)
    const [isOpenRegisterForm, setIsOpenRegisterForm] = useState(false)
    const [user, setUser] = useState()
    const [userName, setUserName] = useState()
    const [email, setEmail] = useState()
    const [password, setPassword] = useState()
    const [confirmPassword, setConfirmPassword] = useState()

    const openLoginForm = () => setIsOpenLoginForm(true)
    const closeLoginForm = () => setIsOpenLoginForm(false)

    const openRegisterForm = () => {
        setUserName()
        setEmail()
        setPassword()
        setConfirmPassword()
        setIsOpenRegisterForm(true)
    }

    const closeRegisterForm = () => setIsOpenRegisterForm(false)


    return (
        <UserContext.Provider
            value={{
                setUser,
                setUserName,
                setEmail,
                setPassword,
                setConfirmPassword,
                openLoginForm,
                closeLoginForm,
                openRegisterForm,
                closeRegisterForm,
                user,
                userName,
                email,
                password,
                confirmPassword
            }}
        >
            {children}
            <LoginModal isOpenLoginForm={isOpenLoginForm} />
            <RegisterModal isOpenRegisterForm={isOpenRegisterForm} />
        </UserContext.Provider>
    )
}
