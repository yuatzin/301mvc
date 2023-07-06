create table ventas
(
    IdVenta int,
    FechaVenta date,
    ClaveP int,
    IdP int,
    constraint pk_ventas primary key (IdVenta),
    constraint fk_ventas_productos foreign key (ClaveP) references productos(claveP),
    constraint fk_ventas_proveedores foreign key (IdP) references proveedores(IdP)
);
