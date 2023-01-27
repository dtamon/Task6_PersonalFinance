import React, { useContext, useState } from "react"
import { useLocalStorage } from "../hooks/useLocalStorage"
import { LoginModal } from "../components/AccountModals/LoginModal"
import { RegisterModal } from "../components/AccountModals/RegisterModal"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const UserContext = React.createContext()

export function useUser() {
    return (
        useContext(UserContext)
    )
}

export const UserProvider = ({ children }) => {
    const [isOpenLoginForm, setIsOpenLoginForm] = useState(false)
    const [isOpenRegisterForm, setIsOpenRegisterForm] = useState(false)
    const [user, setUser] = useLocalStorage("user", {})
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

    const showSuccessToast = (message) => {
        toast.success(message, {
            position: toast.POSITION.BOTTOM_RIGHT
        });
    }

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
                showSuccessToast,
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
            <ToastContainer />
        </UserContext.Provider>
    )
}
