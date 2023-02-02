import { Button, Card, Stack } from "react-bootstrap";
import { currencyFormatter } from "../utils/formatCurrency";
import { useEffect, useState } from "react";
import AddBudgetModal from "./BudgetModals/AddBudgetModal";
import EditCategoryModal from "./CategoryModals/EditCategoryModal";
import BudgetHistoryList from "./BudgetModals/BudgetHistoryList";
import ExpenseService from "../services/ExpenseService";
import IncomeService from "../services/IncomeService";
import { GearFill } from "react-bootstrap-icons";
import { useUser } from "../context/UserContext"

export function BudgetCard({ id, type, refresh }) {
    const { showSuccessToast } = useUser()
    const expenseService = new ExpenseService(), incomeService = new IncomeService()
    const income = "Income", expense = "Expense"
    const [category, setCategory] = useState({})
    const [showAddBudgetModal, setShowAddBudgetModal] = useState(false)
    const [showBudgetHistoryList, setShowBudgetHistoryList] = useState(false)
    const [showEditCategoryModal, setShowEditCategoryModal] = useState(false)

    const classNames = []
    if (type === income) {
        classNames.push("bg-success", "bg-opacity-10")
    } else if (type === expense) {
        classNames.push("bg-danger", "bg-opacity-10")
    }

    const fetchData = async () => {
        if (type === income) {
            await incomeService.getCategoryById(id)
                .then(data => setCategory(data))
        } else if (type === expense) {
            await expenseService.getCategoryById(id)
                .then(data => setCategory(data))
        }
    }

    useEffect(() => {
        fetchData();
    }, [showAddBudgetModal, showEditCategoryModal, showBudgetHistoryList])

    const deleteCategory = async () => {
        if (type === income) {
            await incomeService.deleteCategory(id)
        } else if (type === expense) {
            await expenseService.deleteCategory(id)
        }
        refresh(id)
        showSuccessToast(type + " category deleted successfully")
    }

    return (
        <>
            <Card className={classNames.join(" ")}>
                <Card.Body onDoubleClick={() => { setShowBudgetHistoryList(true) }}>
                    <Card.Title className="d-flex justify-content-between align-items-baseline fw-normal mb-3">
                        <div className="me-2">{category.name}</div>
                        <Stack direction="horizontal" gap="2">
                            <Button variant="outline-none" size="sm" className="ms-auto"
                                onClick={() => setShowAddBudgetModal(true)}>
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    width="20" height="20" fill="currentColor"
                                    className="bi bi-plus-circle-fill" viewBox="0 0 16 16">
                                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z" fill="#384bfc"></path>
                                </svg>
                            </Button>
                            <div className="d-flex align-items-baseline">
                                {currencyFormatter.format(category.sumAmount)}
                            </div>
                        </Stack>
                    </Card.Title>
                    <div className="rounded-circle justify-content-center align-items-center"
                        onClick={() => { setShowEditCategoryModal(true) }}
                        style={{
                            color: "grey",
                            width: ".5rem",
                            height: ".01rem",
                            bottom: 0,
                            right: 0,
                            transform: "translate(-300%, -46000%)",
                        }}
                    ><GearFill /></div>
                </Card.Body>
            </Card>
            {showAddBudgetModal &&
                <AddBudgetModal show={showAddBudgetModal} handleClose={() => setShowAddBudgetModal(false)} {...category} type={type} />
            }
            {showBudgetHistoryList &&
                <BudgetHistoryList show={showBudgetHistoryList} handleClose={() => setShowBudgetHistoryList(false)} categoryId={id} categoryName={category.name} type={type} />
            }
            {showEditCategoryModal &&
                <EditCategoryModal show={showEditCategoryModal} handleClose={() => { setShowEditCategoryModal(false); }} onDelete={(id) => { setShowEditCategoryModal(); deleteCategory(id) }} {...category} type={type} />
            }
        </>
    )
}
