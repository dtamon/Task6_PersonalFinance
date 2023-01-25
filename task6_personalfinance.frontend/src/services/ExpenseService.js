import { authHeader } from "../utils/authHeader"

export default class ExpenseService {
    async getAllCategories() {
        const response = await fetch(`/api/expense/categories`, {
            method: 'GET',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async getCategoryById(id) {
        const response = await fetch(`/api/expense/categories/${id}`, {
            method: 'GET',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        })
        return await response.json()
    }

    async createCategory(name) {
        const response = await fetch(`/api/expense/categories`, {
            method: 'POST',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: name
            })
        })
        return await response.json()
    }

    async updateCategory(id, categoryName) {
        const response = await fetch(`/api/expense/categories/${id}`, {
            method: 'PUT',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: id,
                name: categoryName
            })
        })
        return await response.json()
    }

    async deleteCategory(id) {
        const response = await fetch(`/api/expense/categories/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.text()
    }

    async getExpensesByCategoryId(id) {
        const response = await fetch(`/api/expense/${id}`, {
            method: 'GET',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async getExpenseById(id) {
        const response = await fetch(`/api/expense/getById/${id}`, {
            method: 'GET',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async createBudgetForCategory(id, amount, date, comment) {
        const response = await fetch(`/api/expense`, {
            method: 'POST',
            headers: {
                'Authorization': authHeader(),
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                categoryId: id,
                amount: amount,
                comment: comment,
                date: date
            })
        })
        return await response.json()
    }
}