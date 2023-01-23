import { useEffect, useState } from 'react'
import { Container, Stack, Button, Col } from 'react-bootstrap'
import AddCategoryModal from '../components/AddCategoryModal'
import { BudgetCard } from '../components/BudgetCard'

export function ExpensesList() {
    const [expenseCategories, setExpenseCategories] = useState([])
    const [category, setCategory] = useState()
    const [showAddCategoryModal, setShowAddCategoryModal] = useState(false)

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
                        <BudgetCard {...category} />
                    </Col>
                ))}
                <BudgetCard type="Expense" categoryName="Food" amount={200} id={1}></BudgetCard>
                <BudgetCard type="Expense" categoryName="Food" amount={200} id={1}></BudgetCard>
                <BudgetCard type="Expense" categoryName="Food" amount={200} id={1}></BudgetCard>
                <BudgetCard type="Expense" categoryName="Food" amount={200} id={1}></BudgetCard>
                <BudgetCard type="Expense" categoryName="Food" amount={200} id={1}></BudgetCard>
            </div>
            <AddCategoryModal show={showAddCategoryModal} handleClose={() => setShowAddCategoryModal(false)} />
        </Container>
    )
}
