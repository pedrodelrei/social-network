using System.Collections.Generic;
using System.Linq;
using backend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Data
{
    public class InitialDatabaseData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SocialNetworkContext>();
                context.Database.EnsureCreated();
                context.Database.Migrate();
                if (!context.Relationships.Any())
                {
                    
                    Gender masculino = new Gender {
                        Name = "Masculino",
                        Pronum = "O",
                    };
                    Gender feminino = new Gender {
                        Name = "Feminino",
                        Pronum = "A",
                    };
                    
                    var pai = new Relationship{ RelationshipEnumKey = (int)RelationshipEnum.Parent };
                    var mPai = new RelationshipGender
                    {
                        Gender = masculino,
                        Name = "Pai",
                        InverseName = "Filho",
                        Relationship = pai,
                    };
                    context.RelationshipGenders.Add(mPai);
                    var fPai = new RelationshipGender
                    {
                        Gender = feminino,
                        Name = "Mãe",
                        InverseName = "Filha",
                        Relationship = pai,
                    };
                    context.RelationshipGenders.Add(fPai);

                    
                    var irmao = new Relationship{ RelationshipEnumKey = (int)RelationshipEnum.Sibling };
                    var mIrmao = new RelationshipGender
                    {
                        Gender = masculino,
                        Name = "Irmão",
                        InverseName = "Irmão",
                        Relationship = irmao,
                    };
                    context.RelationshipGenders.Add(mIrmao);
                    var fIrmao = new RelationshipGender
                    {
                        Gender = feminino,
                        Name = "Irmã",
                        InverseName = "Irmã",
                        Relationship = irmao,
                    };
                    context.RelationshipGenders.Add(fIrmao);
                    
                    var namorado = new Relationship{ RelationshipEnumKey = (int)RelationshipEnum.Partner };
                    var mNamorado = new RelationshipGender
                    {
                        Gender = masculino,
                        Name = "Namorado",
                        InverseName = "Namorado",
                        Relationship = namorado,
                    };
                    context.RelationshipGenders.Add(mNamorado);
                    var fNamorado = new RelationshipGender
                    {
                        Gender = feminino,
                        Name = "Namorada",
                        InverseName = "Namorada",
                        Relationship = namorado,
                    };
                    context.RelationshipGenders.Add(fNamorado);

                    var casado = new Relationship{ RelationshipEnumKey = (int)RelationshipEnum.Partner };
                    var mCasado = new RelationshipGender
                    {
                        Gender = masculino,
                        Name = "Marido",
                        InverseName = "Marido",
                        Relationship = casado,
                    };
                    context.RelationshipGenders.Add(mCasado);
                    var fCasado = new RelationshipGender
                    {
                        Gender = feminino,
                        Name = "Mulher",
                        InverseName = "Mulher",
                        Relationship = casado,
                    };
                    context.RelationshipGenders.Add(fCasado);
                    context.SaveChanges();
                }

            }
        }

        public static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>() {
            new Person {Name="Pedro"},
            new Person {Name="Viviane"},
            };
            return people;
        }
    }

}