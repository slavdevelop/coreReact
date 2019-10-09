import React from 'react';

interface ICar {
  color: string;
  model: string;
  topSpeed?: number;
}

interface IProps {
  car: ICar;
}

const CarItem: React.FC<IProps> = ({ car }) => {
  return (
    <div>
      <h1>{car.color}</h1>
    </div>
  );
};

export default CarItem;
