import React, { useState, useEffect } from 'react'
import { currencyFormatter } from '../../utils/formatCurrency'
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js'
import { Pie } from 'react-chartjs-2';
import 'react-toastify/dist/ReactToastify.css'

ChartJS.register(ArcElement, Tooltip, Legend);

export default function Chart({ categories }) {
    const [categoryLabels, setCategoryLabels] = useState([])
    const [categoryData, setCategoryData] = useState([])

    useEffect(() => {
        setCategoryLabels(categories.map(a => a.name))
        setCategoryData(categories.map(a => a.sumAmount))
    }, [categories])

    const data = {
        labels: categoryLabels,
        datasets: [
            {
                data: categoryData,
                backgroundColor: [
                    "#4F3CAF",
                    "#209B47",
                    "#597DAD",
                    "#29EF47",
                    "#1DC99B",
                    "#624113",
                    "#1C6104",
                    "#22B81F",
                    "#81C23F",
                    "#80F579",
                    "#D19A5C",
                    "#645300",
                    "#F6B902",
                    "#63348B",
                    "#74B72D",
                    "#8E5171",
                    "#065D4B",
                    "#E235F8",
                    "#2BEAE4",
                    "#DFCE89",
                    "#4F6B13",
                    "#A4FA68",
                    "#E426CA",
                    "#D30F92",
                    "#CB7F57",
                    "#722A00",
                    "#913E69",
                    "#8B6EFD",
                    "#9F352B",
                    "#105DBD"
                ]
            }
        ],
    };
    const options = {}

    return (
        <div>
            <div style={{ position: 'relative', width: '130%' }}>
                <Pie data={data} options={options} />
            </div>
            <hr />
            <div className='ms-5 me-5 mb-3'>
                {categories.map(category =>
                    <div className='d-flex justify-content-between'>
                        <div className='fs-4'>{category.name}:</div>
                        <div className='fs-4'>{currencyFormatter.format(category.sumAmount)}</div>
                    </div>
                )}
            </div>
        </div >
    )
}
