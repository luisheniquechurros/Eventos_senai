import React from 'react';
import { PieChart, Pie, Cell, ResponsiveContainer, Legend } from 'recharts';
import Menu from '../Menu';

const data = [
  { name: 'Comunidade', value: 400 },
  { name: 'Colaborador', value: 300 },
  { name: 'Aluno Senai', value: 300 },
  { name: 'Infantil', value: 200 },
];

const COLORS = ['#2F5F98', '#2D8BBA', '#41B8D5', '#6CE5E8'];

const Grafico = () => {
  return (
    <ResponsiveContainer width="100%" height={400}>
      <PieChart>
        <Pie
          data={data}
          cx="30%"
          cy="55%"
          labelLine={false}
          label={({name, percent}) => `${name} ${(percent * 100).toFixed(0)}%`}
          outerRadius={160}
          fill="#8884d8"
          dataKey="value"
        >
          {data.map((entry, index) => (
            <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
          ))}
        </Pie>
        
        <Legend
        align="center"
        verticalAlign="middle"
        layout="vertical"
        fontSize={70}
        iconSize={28}
        iconType="circle"
        wrapperStyle={{ lineHeight: '60px', marginLeft: '200px', marginTop: '25px',fontSize: '18px'}} />
        
      </PieChart>
    </ResponsiveContainer>
  );
};

export default Grafico;