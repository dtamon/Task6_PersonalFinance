import { Container } from "react-bootstrap"
import { Navbar } from "./components/Navbar"
import { UserProvider } from "./context/UserContext"
import { Route, Routes } from "react-router-dom"
import { IncomesList } from "./pages/IncomesList"
import { ExpensesList } from "./pages/ExpensesList"
import { Summary } from "./pages/Summary"

function App() {
    return (
        <UserProvider>
            <Navbar />
            <Container>
                <Routes>
                    <Route path="/" element={<Summary />} />
                    <Route path="/incomes" element={<IncomesList />} />
                    <Route path="/expenses" element={<ExpensesList />} />
                </Routes>
            </Container>
        </UserProvider>
    )
}

export default App