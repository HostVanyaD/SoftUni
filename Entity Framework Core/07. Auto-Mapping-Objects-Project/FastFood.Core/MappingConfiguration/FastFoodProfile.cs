namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using System;
    using System.Globalization;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Employee
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(re => re.PositionId, s => s.MapFrom(p => p.Id));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, s => s.MapFrom(e => e.Position.Name));

            //Category
             this.CreateMap<Category, CategoryAllViewModel>();

            //Item
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, s => s.MapFrom(c => c.Id));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(t => t.Category, s => s.MapFrom(i => i.Category.Name));

            //Order
            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(t => t.DateTime, s => s.MapFrom(x => DateTime.UtcNow));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(t => t.OrderId, s=> s.MapFrom(o => o.Id))
                .ForMember(t => t.Employee, s => s.MapFrom(o => o.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
