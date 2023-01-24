import { useEffect, useState } from 'react'
import { Container, Stack, Button, Col } from 'react-bootstrap'
import AddCategoryModal from '../components/AddCategoryModal'
import { BudgetCard } from '../components/BudgetCard'
import ExpenseService from '../services/ExpenseService'

export function ExpensesList() {
    const [expenseCategories, setExpenseCategories] = useState([])
    const [showAddCategoryModal, setShowAddCategoryModal] = useState(false)
    const [showEditCategoryModal, setShowEditCategoryModal] = useState(false)

    useEffect(() => {
        const expenseService = new ExpenseService()
        async function fetchData() {
            await expenseService.getAllCategories()
                .then(data => setExpenseCategories(data))
        }
        fetchData();
    }, [showAddCategoryModal, showEditCategoryModal])

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
                        <BudgetCard {...category} handleClose={() => setShowEditCategoryModal(false)} type="Expense" categories={expenseCategories} />
                    </Col>
                ))}
            </div>
            <AddCategoryModal show={showAddCategoryModal} handleClose={() => setShowAddCategoryModal(false)} type="Expense" />
        </Container>
    )
}
