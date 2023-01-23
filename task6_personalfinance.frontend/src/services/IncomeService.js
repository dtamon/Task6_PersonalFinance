export default class IncomeService {
    async getAllCategories() {
        const response = await fetch(`/api/income/categories`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async getCategoryById(id) {
        const response = await fetch(`/api/income/categories/${id}`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }

    async createCategory(name) {
        const response = await fetch(`/api/income/categories`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: name
            })
        })
        return await response.json()
    }

    async updateCategory(id, name) {
        const response = await fetch(`/api/income/categories/${id}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: id,
                name: name
            })
        })
        return await response.json()
    }

    async deleteCategory(id) {
        const response = await fetch(`/api/income/categories/${id}`, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
        return await response.json()
    }
}