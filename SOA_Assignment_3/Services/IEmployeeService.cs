using System.Text.Json;
using SOA_Assignment_3;

namespace YourNamespace.Services
{
    public class EmployeeService
    {
        private const string FilePath = "Data/employees.json";
        private List<Employee> _employees;

        public EmployeeService()
        {
            LoadEmployees();
        }
        private void LoadEmployees()
        {
            if (File.Exists(FilePath))
            {
                var jsonData = File.ReadAllText(FilePath);
                _employees = JsonSerializer.Deserialize<List<Employee>>(jsonData) ?? new List<Employee>();
            }
            else
            {
                _employees = new List<Employee>();
            }
        }

        // Save employees to JSON
        private void SaveEmployees()
        {
            var jsonData = JsonSerializer.Serialize(_employees, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, jsonData);
        }

        // Get all employees
        public List<Employee> GetAllEmployees() => _employees;

        // Add a new employee
        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
            SaveEmployees();
        }

        public List<Employee> SearchEmployeesById(int? id)
        {
            return _employees.Where(e =>
                (id.HasValue && e.EmployeeID == id)
                )
                .ToList();
        }
        public List<Employee> SearchEmployeesByDesignation( string designation)
        {
            return _employees.Where(e =>
                ((!string.IsNullOrEmpty(designation) && e.Designation == designation))
                )
                .ToList();
        }

        public void DeleteEmployee(int id)
        {
            _employees = _employees.Where(e => e.EmployeeID != id).ToList();
            SaveEmployees();
        }

        public void UpdateDesignation(int id, string newDesignation)
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employee != null)
            {
                employee.Designation = newDesignation;
                SaveEmployees();
            }
        }
        public List<Employee> GetJavaExperts()
        {
            return _employees
                .Where(e => e.KnownLanguages.Any(lang => lang.LanguageName == "Java" && lang.ScoreOutof100 > 50))
                .OrderBy(e => e.KnownLanguages.First(lang => lang.LanguageName == "Java").ScoreOutof100)
                .ToList();
        }
    }
}
