import { useEffect, useState } from 'react'
import { Container, Stack, Button, Col } from 'react-bootstrap'
import AddCategoryModal from '../components/CategoryModals/AddCategoryModal'
import { BudgetCard } from '../components/BudgetCard'
import ExpenseService from '../services/ExpenseService'

export function ExpensesList() {
    const expenseService = new ExpenseService()
    const [expenseCategories, setExpenseCategories] = useState([])
    const [showAddCategoryModal, setShowAddCategoryModal] = useState(false)
    const [refresh, setRefresh] = useState()

    const fetchData = async () => {
        await expenseService.getAllCategories()
            .then(data => setExpenseCategories(data))
    }

    useEffect(() => {
        fetchData();
    }, [showAddCategoryModal, refresh])

    return (
        <Container className="my-4">
            <Stack direction="horizontal" gap="2" className="mb-4">
                <h1 className="me-auto">Your Expenses</h1>
                <Button variant="primary"
                    onClick={() => setShowAddCategoryModal(true)}
                >
                    Add Category
                </Button>
            </Stack>
            <div
                style={{
                    display: "grid",
                    gridTemplateColumns: "repeat(auto-fill, minmax(300px, 1fr))",
                    gap: "1rem",
                    alignItems: "flex-start"
                }}
            >
                {expenseCategories.map(category => (
                    <Col key={category.id}>
                        <BudgetCard {...category} refresh={(e) => setRefresh(e)} type="Expense" />
                    </Col>
                ))}
            </div>
            <AddCategoryModal show={showAddCategoryModal} handleClose={() => setShowAddCategoryModal(false)} type="Expense" />
        </Container>
    )
}
