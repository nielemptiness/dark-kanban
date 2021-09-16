using System;
using System.Linq;
using DarkKanban.Core.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkKanban.Core.Database.Helpers
{
    public class MigrationHelper
    {
        public static void InitDefaultBoard(MigrationBuilder migrationBuilder)
        {
            var boardId = Guid.NewGuid();
            
            migrationBuilder.InsertData(
                table: nameof(Board),
                columns: new [] { "Id", "Name", "Description"},
                values: new object[] { boardId, "My board", "Your default kanban board. Look around to get familiar with app :)" }
            );

            var defaultColumns = ColumnsInitHelper.CreateDefaultColumns(boardId);
            
            foreach (var tableInsertConfig in defaultColumns)
            {
                migrationBuilder.InsertData(
                    table: tableInsertConfig.TableName,
                    columns: tableInsertConfig.Columns,
                    values: tableInsertConfig.Values
                );
            }

            migrationBuilder.InsertData(
                table: nameof(Record),
                columns:  new [] { "Id", "Name", "Description", "ColumnId" },
                values: new object[]
                {
                    Guid.NewGuid(), 
                    "First task!", 
                    "This is a sample task. Feel free to edit or delete it.", 
                    defaultColumns.First().EntityId
                }
            );
        }

    }
}