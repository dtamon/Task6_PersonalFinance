import { useEffect, useState } from 'react'
import { Container, Stack, Button, Col } from 'react-bootstrap'
import AddCategoryModal from '../components/AddCategoryModal'
import { BudgetCard } from '../components/BudgetCard'
import IncomeService from '../services/IncomeService'

export function IncomesList() {
    const incomeService = new IncomeService()
    const [incomeCategories, setIncomeCategories] = useState([])
    const [showAddCategoryModal, setShowAddCategoryModal] = useState(false)

    const fetchData = async () => {
        await incomeService.getAllCategories()
            .then(data => setIncomeCategories(data))
    }

    useEffect(() => {
        fetchData();
    }, [])

    return (
        <Container className="my-4">
            <Stack direction="horizontal" gap="2" className="mb-4">
                <h1 className="me-auto">Your Incomes</h1>
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
                {incomeCategories.map(category => (
                    <Col key={category.id}>
                        <BudgetCard {...category} />
                    </Col>
                ))}
            </div>
            <AddCategoryModal show={showAddCategoryModal} handleClose={() => setShowAddCategoryModal(false)} />
        </Container>
    )
}
